import { Routes } from "@angular/router";
import { StopView } from "../components/stop-view/stop-view";
import { StopViewDetails } from "../components/stop-view-details/stop-view-details";


export const routes: Routes = [
    {
        path:'',
        component: StopView
    },
    { path: ':id', component: StopViewDetails }
    
];