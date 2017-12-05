import '../globals'
import 'tslib'

import { AppRouter } from 'core/router'
import { UserStore } from 'core/user'

interface Props {

}

export class App extends Component<Props, {}> {
    private stores: {
        user: UserStore
    }

    constructor(props: Props) {
        super(props)

        const user = new UserStore()

        this.stores = { user }
    }

    render() {
        return (
            <Provider {...this.stores}>
                <AppRouter />
            </Provider>

        )
    }
}