import { Routes } from "@angular/router";
import { JourneyViewDetails } from "../components/journey-view-details/journey-view-details";
import { JourneyView } from "../components/journey-view/journey-view";

export const routes: Routes = [
    {
        path:'',
        component: JourneyView
    },
    { path: ':id', component: JourneyViewDetails }
    
];