/// <reference types="vite/client" />

interface ImportMetaEnv {
    readonly VITE_SERVER_APIKEY: string
    readonly VITE_SERVER_APIURL: string
}

interface ImportMeta {
    readonly env: ImportMetaEnv
}