import { EditMatchSet } from "components";
import { IMatchSet, IGolfer } from "models";

const golfers: IGolfer[] = [
    { id: 1, firstName: "A", lastName: "A", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
    { id: 2, firstName: "B", lastName: "B", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
    { id: 3, firstName: "C", lastName: "C", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
    { id: 4, firstName: "D", lastName: "D", membershipId: "", handicap: 0, isAdmin: false, isActive: true }

];

const matchSet: IMatchSet = {
    id: 1,
    seasonId: 1,
    matchSetNumber: 1,
    matches: [
        { id: 1, golferA: golfers[0], golferB: golfers[1] }
    ],
    inactives: [
        { id: 1, matchSetId: 1, golferId: 3 }
    ]
};

describe("The matchset editor", () => {

    it("should organize view model", () => {
        var ems = new EditMatchSet({ matchSetId: 1 });
        var state = ems.calculateState(golfers, matchSet);
        
        expect(state.inactives.length).toBe(1);
        expect(state.inactives[0].firstName).toBe("C");
        expect(state.matchset.matches.length).toBe(1);
        expect(state.matchset.matches[0].golferA.id).toBe(1);
        expect(state.golfers.length).toBe(1);
    });

});