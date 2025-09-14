import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path:'journey',
        loadChildren: () => import('./journey/routing/journey-routing').then(m => m.routes)
    },
    {
        path:'stop',
        loadChildren: () => import('./stops/routing/stop.routing').then(m => m.routes)
    }
];
