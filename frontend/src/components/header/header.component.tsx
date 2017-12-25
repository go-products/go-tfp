import { UserStore } from 'core/user'

interface Props {
  user?: UserStore
}

@observer(['user'])
export class Header extends Component<Props, {}> {
  render() {
    if (!this.props.user) return null

    return (
      <header className="header">
        <Link to="/" className="header__logo">
          I'm logo!
        </Link>

        <nav className="header__nav">
          <li className="header__item">
            <Link to="registration" className="header__link">
              Registration
            </Link>
          </li>
          <li className="header__item">
            <Link className="header__link" to="login">
              Login
            </Link>
          </li>
        </nav>

        <div className="header__account">
          {this.props.user.isAuth ? 'was logged' : 'wasnt logged'}
        </div>
      </header>
    )
  }
}
