import { ref } from 'vue'

interface ToastOptions {
  id?: number
  title?: string
  message: string
  type?: 'success' | 'error' | 'warning' | 'info'
  duration?: number
}

const toasts = ref<ToastOptions[]>([])

export const useToast = () => {
  const showToast = (options: ToastOptions) => {
    const toast: ToastOptions = {
      ...options,
      id: Date.now()
    }
    toasts.value.push(toast)
    
    if (options.duration !== 0) {
      setTimeout(() => {
        removeToast(toast.id!)
      }, options.duration || 3000)
    }
  }

  const removeToast = (id: number) => {
    const index = toasts.value.findIndex(toast => toast.id === id)
    if (index > -1) {
      toasts.value.splice(index, 1)
    }
  }

  const success = (message: string, title?: string) => {
    showToast({ message, title, type: 'success' })
  }

  const error = (message: string, title?: string) => {
    showToast({ message, title, type: 'error' })
  }

  const warning = (message: string, title?: string) => {
    showToast({ message, title, type: 'warning' })
  }

  const info = (message: string, title?: string) => {
    showToast({ message, title, type: 'info' })
  }

  return {
    toasts,
    showToast,
    removeToast,
    success,
    error,
    warning,
    info
  }
} 