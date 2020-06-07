import { RootStore } from "./rootStore";
import { observable, action, reaction } from "mobx";

export default class CommonStore {
    rootStore: RootStore

    constructor(rootStore: RootStore) {
        this.rootStore = rootStore;

        // a reaction runs whenever the observable is set
        reaction(
            () => this.token,
            token => {
                if(token) {
                    window.localStorage.setItem('RealState_jwt', token); // any  key we want
                }
                else {
                    window.localStorage.removeItem('RealState_jwt');
                }
            }
            )
    }

    @observable token: string | null = window.localStorage.getItem('RealState_jwt');
    @observable appLoaded = false;

    @action setToken = (token: string | null) => {        
        this.token = token;
    }

    @action setAppLoaded = () => {
        this.appLoaded = true;
    }
}