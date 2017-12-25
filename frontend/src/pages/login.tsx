import { Header } from 'components/header'
import { Login } from 'components/login'

export class LoginPage extends Component<{}, {}> {
  render() {
    return (
      <div>
        <div className="layout__max">
          <Header />
        </div>
        <div className="layout__container">
          <Login />
        </div>
      </div>
    )
  }
}
