import { Header } from 'components/header'
import { Zoomer } from 'components/zoomer'

interface Props {
  path?: string
}

export class HomePage extends Component<Props, {}> {
  render() {
    return (
      <div>
        <Header />
        <Link to="registration">Register</Link>
        <Link to="login">Login</Link>
        <Zoomer
          imgSrcMin="https://gitlab.bettings.ch/uploads/-/system/user/avatar/24/avatar.png"
          imgSrcFull="https://www.google.by/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png"
        />
      </div>
    )
  }
}
