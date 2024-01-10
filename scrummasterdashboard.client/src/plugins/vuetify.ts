import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'
import { createVuetify, type ThemeDefinition } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const defaultCustomTheme: ThemeDefinition = {
  dark: false,
  colors: {
    background: '#20202c',
    surface: '#112B3C',
    primary: '#112B3C',
    'primary-darken-1': '#191a23',
    'primary-lighten-1': '#333446',
    secondary: '#ef9508',
    error: '#B00020',
    info: '#2196F3',
    success: '#4CAF50',
    warning: '#FB8C00',
  }
}

export default createVuetify({
  components,
  directives,
  theme: {
    defaultTheme: 'defaultCustomTheme',
    themes: {
      defaultCustomTheme
    }
  }
})
