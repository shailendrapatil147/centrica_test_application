export class UserByCity{
    userId!: number;
    userName!: string;
    cityId!: number;
    cityName!: string;
    roleId!: number;
    roleName!: string;
    userRoleId!: number;
}

export class Role {
    public id!: number;
    public name!: string;
    public description!: string;
}

export class User {
    public id!: number;
    public name!: string;
}

export class UserRole{
    userId!: number;
    cityId!: number;
    roleId!: number;
}

