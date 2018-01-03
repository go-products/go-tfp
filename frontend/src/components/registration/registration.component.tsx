import { Input, Field } from 'core/form'
import { UserStore } from 'core/user'
import { IRegistrationFields } from './fields'
import { RegistrationForm } from './form'
import { validators } from 'core/form'

interface Props {
  user?: UserStore
}

@observer
export class Registration extends Component<Props, {}> {
  fields: IRegistrationFields
  form: RegistrationForm
  @observable error: string

  constructor(props: Props) {
    super(props)

    this.handleSubmit = this.handleSubmit.bind(this)
  }

  componentWillMount() {
    const { maxLength, minLength, required, compared } = validators
    this.fields = {
      firstName: new Field(required(), minLength(2)),
      lastName: new Field(required(), minLength(5), maxLength(25)),
      email: new Field(required()),
      password: new Field(required()),
      confirmPassword: new Field(required()),
    }
    this.fields.confirmPassword.validators.push(
      compared(this.fields.password, 'Пароли не совпадают')
    )

    this.form = new RegistrationForm(this.fields)
  }

  async handleSubmit(event: any) {
    event.preventDefault()
    const isSuccess = await this.form.submit()
    console.log(isSuccess)
  }

  render() {
    const { firstName, lastName, email, password, confirmPassword } = this.fields

    return (
      <div className="block">
        <div className="reg__wrapper">
          <form className="reg__form" onSubmit={this.handleSubmit}>
            {this.error}
            <Input label="Имя" field={firstName} />
            <Input label="Фамилия" field={lastName} />
            <Input label="Пароль" type="password" field={password} />
            <Input label="Повторите пороль" type="password" field={confirmPassword} />
            <Input label="Email" type="text" field={email} />
            <div className="field">
              <label />
              <button className="btn btn_accent mw_fl" type="submit">
                Submit
              </button>
            </div>
          </form>

          <div className="reg__info">Some Info</div>
        </div>
      </div>
    )
  }
}
