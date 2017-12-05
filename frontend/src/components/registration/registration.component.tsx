import { Input, Field } from 'core/form'
import { UserStore } from 'core/user'
import { http } from 'core/http'
import { IRegistration } from './registration'

interface Props {
    path?: string
    user?: UserStore
}

@observer
export class Registration extends Component<Props, {}> {
    data: IRegistration
    @observable error: string

    constructor(props: Props) {
        super(props)

        this.data = {
            name: new Field(),
            email: new Field(),
            username: new Field(),
            password: new Field()
        }
        this.handleSubmit = this.handleSubmit.bind(this)
    }

    handleSubmit(event: any) {
        event.preventDefault()
        const data = {
            name: this.data.name.value,
            email: this.data.email.value,
            username: this.data.username.value,
            password: this.data.password.value
        }

        http.post('users/register', data)
            .then(resp => {
                if (resp.data.success) {

                } else {
                    this.error = resp.data.msg
                }
            })
            .catch(error => console.error(error))
    }

    render() {
        const { name, email, username, password } = this.data

        return (
            <form onSubmit={this.handleSubmit}>
                {this.error}
                <Input label='Имя' field={name} />
                <Input label='E-mail' field={email} />
                <Input label='Логин' field={username} />
                <Input label='Пароль' type='password' field={password} />
                <button type='submit'>Submit</button>
            </form>
        )
    }
}