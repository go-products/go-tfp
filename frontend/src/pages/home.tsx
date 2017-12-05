import { Header } from 'components/header'

interface Props {
    path?: string
}

export class HomePage extends Component<Props, {}> {
    render() {
        return (
            <div>
                <Header />
                <Link to='registration'>Register</Link>
                <Link to='login'>Login</Link>
            </div>
        )
    }
}