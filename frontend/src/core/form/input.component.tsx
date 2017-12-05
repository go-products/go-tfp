import { Field } from './field.model'

interface Props {
    field: Field
    label: string
    type?: string
}

@observer
export class Input extends Component<Props, {}> {
    render() {
        const { field, label, type } = this.props

        return (
            <div>
                <label>{label}</label>
                <input
                    type={type || 'text'}
                    value={field.value}
                    onChange={
                        (event: any) => {
                            event.preventDefault()
                            field.value = event.currentTarget.value
                        }
                    }
                />
            </div>
        )
    }
}
