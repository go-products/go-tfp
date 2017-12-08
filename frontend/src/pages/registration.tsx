import { Header } from 'components/header'
import { Registration } from 'components/registration'

interface Props {
  path?: string
}

export class RegistrationPage extends Component<Props, {}> {
  render() {
    return (
      <div>
        <div className="layout__max">
          <Header />
        </div>
        <div className="layout__container">
          <Registration />
          <div className="block">123</div>
        </div>
        <div className="layout__container horizontal">
          <div className="block">Test Layout</div>
          <div className="block">Test 2</div>
        </div>
      </div>
    )
  }
}
