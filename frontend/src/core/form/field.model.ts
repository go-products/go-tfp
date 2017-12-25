export class Field {
  @observable value = ''

  @action
  onChange(event: any) {
    event.preventDefault()
    this.value = event.currentTarget.value
  }

  @observable
  isValid(): boolean {
    return this.value ? true : false
  }
}
