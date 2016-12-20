interface IHasIdentifier {
    id: number
}

export function find<T>(array: T[], predicate :(value: T, index?: number) => boolean) {
    for(var i = 0; i < array.length; i++) {
        if(predicate(array[i], i)) {
            return array[i];
        }
    }
    return undefined;
}

export function findById<T extends IHasIdentifier>(array: T[], id: number){
    return find(array, thing => this.id === id);
}
