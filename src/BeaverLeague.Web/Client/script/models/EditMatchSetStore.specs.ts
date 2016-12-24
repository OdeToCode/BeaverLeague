import * as React from "React";
import { IMatchSet, ISelectableGolfer, EditMatchSetStore } from "models";

class FakeComponent extends React.Component<any, EditMatchSetStore> {
    setState(data: any) {}
}

describe("The matchset editor", () => {

    let golfers: ISelectableGolfer[];
    let matchSet: IMatchSet;

    beforeEach(() => {
        golfers = [
            { id: 1, firstName: "A", lastName: "A", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
            { id: 2, firstName: "B", lastName: "B", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
            { id: 3, firstName: "C", lastName: "C", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
            { id: 4, firstName: "D", lastName: "D", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
            { id: 5, firstName: "E", lastName: "E", membershipId: "", handicap: 0, isAdmin: false, isActive: true },
            { id: 6, firstName: "F", lastName: "F", membershipId: "", handicap: 0, isAdmin: false, isActive: true }
        ];

        matchSet = {
            id: 1,
            seasonId: 1,
            matchSetNumber: 1,
            matches: [
                { id: 10, golferA: golfers[0], golferB: golfers[1] }
            ],
            inactives: [
                { id: 1, matchSetId: 1, golferId: 3 }
            ]
        };
    });


    it("should organize view model", () => {
        var ems = new EditMatchSetStore(new FakeComponent());
        ems.arrangeData(golfers, matchSet);
        
        expect(ems.inactives.length).toBe(1);
        expect(ems.inactives[0].firstName).toBe("C");
        expect(ems.matchset.matches.length).toBe(1);
        expect(ems.matchset.matches[0].golferA.id).toBe(1);
        expect(ems.golfers.length).toBe(3);
    });

    it("should select a golfer", () => {
        var ems = new EditMatchSetStore(new FakeComponent());
        ems.arrangeData(golfers, matchSet);
        ems.selectGolfer(ems.golfers[1]);
        expect(ems.golfers[1].isSelected).toBe(true);
    });

    it("should pair golfers when 2 golfers selected", () => {
        var ems = new EditMatchSetStore(new FakeComponent());
        ems.arrangeData(golfers, matchSet);
        ems.selectGolfer(ems.golfers[2]);
        ems.selectGolfer(ems.golfers[0]);

        expect(ems.golfers.length).toBe(1);
        expect(ems.golfers[0].firstName).toBe("E");
        expect(ems.matchset.matches.length).toBe(2);
        expect(ems.matchset.matches[1].golferA.firstName).toBe("F");
        expect(ems.matchset.matches[1].golferB.firstName).toBe("D");
        expect(ems.matchset.matches[1].id).toBe(-2);
    });

    it("twice selected golfer undoes selection", () => {
        var ems = new EditMatchSetStore(new FakeComponent());
        ems.arrangeData(golfers, matchSet);
        ems.selectGolfer(ems.golfers[1]);
        ems.selectGolfer(ems.golfers[1]);
        ems.selectGolfer(ems.golfers[1]);
        ems.selectGolfer(ems.golfers[1]);

        expect(ems.golfers.length).toBe(3);
        expect(ems.matchset.matches.length).toBe(1);
        expect(ems.golfers[1].isSelected).toBe(false);
    });

    it("can delete a match", () => {
        var ems = new EditMatchSetStore(new FakeComponent());
        ems.arrangeData(golfers, matchSet);
        
        ems.deleteMatch(10);

        expect(ems.matchset.matches.length).toBe(0);
        expect(ems.golfers.length).toBe(5);
    });
});