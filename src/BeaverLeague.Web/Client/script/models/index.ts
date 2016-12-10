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