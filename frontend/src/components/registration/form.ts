import { http } from 'core/http'
import { Form } from 'core/form'

export class RegistrationForm extends Form {
  submit() {
    if (!this.isValid()) {
      return Promise.resolve(false)
    }

    const data = this.serialize()

    return http
      .post('Account/Register', data)
      .then(() => true)
      .catch(() => false)
  }
}
