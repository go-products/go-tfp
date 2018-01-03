import { Field } from './'

export interface IFormFields {
  [field: string]: Field
}

export interface ISerializedFields {
  [fields: string]: string
}

export abstract class Form {
  @observable fields: IFormFields

  constructor(fields: IFormFields) {
    this.fields = fields
  }

  serialize(): ISerializedFields {
    let data: ISerializedFields = {}
    for (let fieldName in this.fields) {
      data[fieldName] = this.fields[fieldName].value
    }
    return data
  }

  isValid(): boolean {
    const fieldNames = Object.keys(this.fields)

    fieldNames.map((fieldName: string) => {
      this.fields[fieldName].checkValid()
    })

    return !fieldNames.find((fieldName: string) => !!this.fields[fieldName].isValid === false)
  }

  submit(): void {}
}
