import { Header } from 'components/header'
import { Registration } from 'components/registration'

interface Props {
    path?: string
}

export class RegistrationPage extends Component<Props, {}> {
    render() {
        return (
            <div>
                <Header />
                1
                <Registration />
            </div>
        )
    }
}