import { Input, Field, IFormFields } from 'core/form'
import { UserStore } from 'core/user'
import { LoginForm } from './form'

interface ILoginFields extends IFormFields {
  email: Field
  password: Field
}

interface Props {
  user?: UserStore
}

@observer(['user'])
export class Login extends Component<Props, {}> {
  fields: ILoginFields
  form: LoginForm

  constructor(props: Props) {
    super(props)

    this.handleSubmit = this.handleSubmit.bind(this)
  }

  componentWillMount() {
    this.fields = {
      email: new Field(),
      password: new Field(),
    }
    this.form = new LoginForm(this.fields)
  }

  async handleSubmit(event: any) {
    event.preventDefault()
    const response = await this.form.submit()

    response.success && this.props.user && this.props.user.login(response.token)
  }

  render() {
    const { email, password } = this.fields

    return (
      <div className="block">
        <div className="reg__wrapper">
          <form className="reg__form" onSubmit={this.handleSubmit}>
            <Input label="Email" type="email" field={email} />
            <Input label="Пароль" type="password" field={password} />
            <div className="field">
              <label />
              <button className="btn btn_accent mw_fl" type="submit">
                Логин
              </button>
            </div>
          </form>
        </div>
      </div>
    )
  }
}
