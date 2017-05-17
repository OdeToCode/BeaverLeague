import * as React from "React";
import {api} from "services";
import { ISelectableGolfer, IMatchSet, IInactiveDescription } from "models";

export interface IEditMatchSetState {
    golfers: ISelectableGolfer[];
    matchset: IMatchSet;
    inactives: IInactiveDescription[];
}

export class EditMatchSetStore {

    component: React.Component<any, IEditMatchSetState>;
    golfers: ISelectableGolfer[];
    matchset: IMatchSet;
    inactives: IInactiveDescription[];
    selected: ISelectableGolfer[];

    constructor(component: React.Component<any, IEditMatchSetState>) {
        this.component = component;
        this.golfers = [];
        this.inactives = [];
        this.selected = [];
        this.matchset = {
            id: null,
            seasonId: null,
            matchSetNumber: null,
            inactives: [],
            matches: []
        }
    }

    async load(id: number) {
        let golfers = await api.getActiveGolfers();
        let matchset = await api.getMatchSet(id);
        this.arrangeData(golfers, matchset);
    }

    produceState() {
        return {
            golfers: this.golfers,
            matchset: this.matchset,
            inactives: this.inactives
        }
    }

    arrangeData(golfers: ISelectableGolfer[], matchset: IMatchSet) {
        let availableGolfers = [];
        let inactives = [];
        
        for(let golfer of golfers) {
            let playing = matchset.matches.filter(m => 
                (m.golferA && m.golferA.id == golfer.id) || 
                (m.golferB && m.golferB.id == golfer.id));
            let inactive = matchset.inactives.filter(i => i.golferId == golfer.id);
            if(playing.length === 0 && inactive.length === 0) {
                availableGolfers.push(golfer);
            }
        }

        for(let inactive of matchset.inactives) {        
            let find = golfers.filter(g => g.id == inactive.golferId);
            if(find.length > 0) {
                inactives.push({
                    id: find[0].id,
                    firstName : find[0].firstName,
                    lastName : find[0].lastName
                });
            }
        }

        this.golfers = availableGolfers;
        this.matchset = matchset;
        this.inactives = inactives;
        this.component.setState(this.produceState());
    }

    pairGolfers() {        
        this.golfers.splice(this.golfers.indexOf(this.selected[0]),1);
        this.golfers.splice(this.golfers.indexOf(this.selected[1]),1);
        this.matchset.matches.push({
            id: -(this.matchset.matches.length + 1), golferA: this.selected[0], golferB: this.selected[1]
        });
    }

    deleteMatch(id: number) {
             
    }

    selectGolfer(golfer: ISelectableGolfer) {
        
        golfer.isSelected = !golfer.isSelected;

        if(golfer.isSelected) {
            this.selected.push(golfer);
        } else {
            this.selected.splice(this.selected.indexOf(golfer), 1);
        }
        
        if(this.selected.length == 2) {
            this.pairGolfers();
            this.selected = [];
        }

        this.component.setState(this.produceState());       
    }
}