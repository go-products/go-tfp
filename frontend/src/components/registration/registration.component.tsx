import { Input, Field } from 'core/form'
import { UserStore } from 'core/user'
import { IRegistrationFields } from './fields'
import { RegistrationForm } from './form'

interface Props {
  path?: string
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
    this.fields = {
      firstName: new Field(),
      secondName: new Field(),
      email: new Field(),
      confirmPassword: new Field(),
      password: new Field(),
    }
    this.form = new RegistrationForm(this.fields)
  }

  async handleSubmit(event: any) {
    event.preventDefault()
    const isSuccess = await this.form.submit()
    console.log(isSuccess)
  }

  render() {
    const { firstName, secondName, email, password, confirmPassword } = this.fields

    return (
      <div className="block">
        <div className="reg__wrapper">
          <form className="reg__form" onSubmit={this.handleSubmit}>
            {this.error}
            <Input label="Имя" field={firstName} />
            <Input label="Фамилия" field={secondName} />
            <Input label="Пароль" type="password" field={password} />
            <Input label="Повторите пороль" type="password" field={confirmPassword} />
            <Input label="Email" type="email" field={email} />
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
