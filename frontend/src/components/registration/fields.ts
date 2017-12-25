import { Field, IFormFields } from 'core/form'

export interface IRegistrationFields extends IFormFields {
  firstName: Field
  lastName: Field
  password: Field
  confirmPassword: Field
  email: Field
}
