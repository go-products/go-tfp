import { http } from 'core/http'
import { Form } from 'core/form'
import { IRegistrationFields } from './fields'

export class RegistrationForm extends Form {
  constructor(fields: IRegistrationFields) {
    super(fields)
  }

  submit() {
    if (!this.isValid()) {
      return Promise.resolve(false)
    }

    const data = this.serialize()

    http.post('Account/Register', data)
  }
}
