export interface RouteDetails {
    Title: string
    Route: string
    Icon?: string
    IsExternalLink?: boolean
}

interface IRoute {
    LandingPage: RouteDetails
}

const routes: IRoute = {
    LandingPage: { Title: 'LandingPage', Route: '/' },
}

export default routes