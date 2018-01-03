import { Validator } from './validators'

export class Field {
  @observable value: string = ''
  @observable isValid: boolean = true
  @observable errorMsg: string = ''
  validators: Validator[]

  constructor(...validators: Validator[]) {
    this.validators = validators
  }

  @action
  onChange(event: any) {
    event.preventDefault()
    this.value = event.currentTarget.value
    this.checkValid()
  }

  @action
  checkValid(): void {
    this.isValid = true
    this.errorMsg = ''

    this.validators.map(validator => {
      const fieldValid = validator(this.value)
      if (!fieldValid.isValid) {
        this.isValid = false
        this.errorMsg = fieldValid.msg
      }
    })
  }
}
