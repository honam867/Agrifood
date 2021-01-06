export class User {
    id: any;
    userName: string;
    email: string;
    phoneNumber: string;
    avatarURL: string;
    role: string;
    status: boolean;
    createdDate: Date;
    createdByUserName: string;
    updatedDate: Date;
    updatedByUserName: string;
    selectedFarmer: boolean;
    constructor() {
        this.selectedFarmer = true;
    }
}