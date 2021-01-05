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

    constructor() {
        this.id = 0;
        this.userName = '';
        this.email = '';
        this.phoneNumber = '';
        this.avatarURL = '';
        this.role = '';
        this.status = true;
    }
}
