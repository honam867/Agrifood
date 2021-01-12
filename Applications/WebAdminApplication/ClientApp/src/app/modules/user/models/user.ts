export class User {
    id: any;
    userName: string;
    email: string;
    phoneNumber: string;
    avatarURL: string;
    role: string;
    roles: string;
    status: boolean;
    createdDate: Date;
    createdByUserName: string;
    updatedDate: Date;
    updatedByUserName: string;
    selectedFarmer: boolean;
    selectedEmployee: boolean;
    constructor() {
        this.selectedFarmer = true;
    }
}
