import { Switch, Route } from 'react-router-dom'

import { HomePage } from 'pages/home'
import { RegistrationPage } from 'pages/registration'
import { LoginPage } from 'pages/login'

export class AppRouter extends Component<{}, {}> {

    render() {
        return (
            <Switch>
                <Route exact path='/' component={HomePage} />
                <Route path='/registration' component={RegistrationPage} />
                <Route path='/login' component={LoginPage} />
            </Switch>
        )
    }
}