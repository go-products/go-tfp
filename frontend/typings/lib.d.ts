import * as R from 'react'
import * as mobxReact from 'mobx-react'
import * as mobx from 'mobx'
import * as reactRouter from 'react-router-dom'

declare global {
  const React: typeof R
  const Component: typeof R.Component
  const inject: typeof mobxReact.inject
  const observer: typeof mobxReact.observer
  const Provider: typeof mobxReact.Provider
  const observable: typeof mobx.observable
  const action: typeof mobx.action
  const computed: typeof mobx.computed
  const runInAction: typeof mobx.runInAction
  const Link: typeof reactRouter.Link
  type IObservableArray<T> = mobx.IObservableArray<T>

  // Custom Example
  type Stage = 'dev' | 'prod'

  interface Money {
    amount: number
    currency: string
  }

  // System

  interface ISystemStatic {
    import(request: string): Promise<any>
  }
  const System: ISystemStatic

  interface Window {
    sg: any
  }

  interface Dict {
    [key: string]: string
  }
}
