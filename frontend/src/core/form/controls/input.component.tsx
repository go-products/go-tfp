import { Field } from '../field.model'

import * as cn from 'classnames'

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
      <div className="field">
        <label>{label}</label>
        <input
          type={type || 'text'}
          value={field.value}
          onChange={e => field.onChange(e)}
          className={cn({ error: !field.isValid })}
        />
        <div className="field__error_msg">{field.errorMsg}</div>
      </div>
    )
  }
}
