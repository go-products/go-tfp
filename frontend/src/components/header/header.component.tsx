interface Props {}

export class Header extends Component<Props, {}> {
  render() {
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

        <div className="header__account">account</div>
      </header>
    )
  }
}
