import * as React from 'react'
import { inject, observer, Provider } from 'mobx-react'
import { observable, action, computed, runInAction } from 'mobx'
import { Link } from 'react-router-dom'

(function (window: any) {
    window.React = React
    window.Component = React.Component
    window.Provider = Provider
    window.inject = inject
    window.observer = observer
    window.observable = observable
    window.action = action
    window.computed = computed
    window.runInAction = runInAction
    window.Link = Link
})(window)
