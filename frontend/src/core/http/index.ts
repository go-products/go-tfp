import axios from 'axios'
import { CONFIG } from 'core/config'

export const http = axios.create({
  baseURL: CONFIG.serverHost,
  withCredentials: true,
})
