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
    for (let fieldName in this.fields) {
      if (!this.fields[fieldName].isValid()) {
        return false
      }
    }
    return true
  }

  submit(): void {}
}
