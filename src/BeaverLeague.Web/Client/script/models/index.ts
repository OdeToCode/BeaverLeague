export interface IGolfer {
    id: number;
    membershipId: string;
    firstName: string;
    lastName: string;
    handicap: number;
    isAdmin: boolean;
    isActive: boolean;
}

export interface IMatch {
    id: number;
    golferA: IGolfer;
    golferB: IGolfer;
}

export interface IMatchSetInactiveGolfer {
    id: number;
    matchSetId: number;
    golferId: number;
}

export interface IMatchSet {
    id: number;
    seasonId: number;
    matchSetNumber: number;
    matches: IMatch[];
    inactives: IMatchSetInactiveGolfer[]
}

export interface IInactiveDescription {
    id: number; 
    firstName: string; 
    lastName: string;
}

export interface ISelectableGolfer extends IGolfer {
    isSelected?: boolean;
}

export * from "./EditMatchSetStore";