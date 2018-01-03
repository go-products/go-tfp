import { Field } from 'core/form'

const required = (msg: string = 'Поле обязательно для заполнения'): Validator => (
  value: string
) => ({
  isValid: !!value,
  msg,
})

const minLength = (
  minLength: number,
  msg: string = `Минимум симовлов: ${minLength}`
): Validator => (value: string) => ({ isValid: value.length >= minLength, msg })

const maxLength = (
  maxLength: number,
  msg: string = `Максимум симовлов: ${maxLength}`
): Validator => (value: string) => ({ isValid: value.length <= maxLength, msg })

const compared = (field: Field, msg: string = 'Поля не совпадают'): Validator => (
  value: string
) => ({
  isValid: value === field.value,
  msg,
})

export const validators = { required, minLength, maxLength, compared }

export type Validator = (value: string) => { isValid: boolean; msg: string }
