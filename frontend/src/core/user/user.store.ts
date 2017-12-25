import { CONFIG } from 'core/config'

// import { IRegistrationFields } from 'components/registration'

// const server = 'http://localhost:8080/api/'

export class UserStore {
  @observable isAuth: boolean = false

  constructor() {
    this.checkAuth()
  }

  @action
  checkAuth() {
    this.isAuth = localStorage.getItem(CONFIG.nameKeyToken) ? true : false
  }

  login(token: string) {
    localStorage.setItem(CONFIG.nameKeyToken, token)
    this.checkAuth()
  }

  logout() {
    localStorage.removeItem(CONFIG.nameKeyToken)
    this.checkAuth()
  }
}
