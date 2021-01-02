export class RoleOfUser {
    userId: number;
    roleName: string;

    constructor(userId: number = 0) {
        this.userId = userId;
        this.roleName = '';
    }
}
