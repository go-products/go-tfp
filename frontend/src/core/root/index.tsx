import { render } from 'react-dom'
import { BrowserRouter } from 'react-router-dom'
import { App } from 'core/app'

render(
  <BrowserRouter>
    <App />
  </BrowserRouter>,
  document.getElementById('root') || document.body
)
