import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from "yup";
import IProfileCreationRequest from "../../interface/i-profile-creation-request";
import { useDispatch } from "react-redux";
import { postNewUser } from "../../redux/actions/register-action-creator";

export default function Register() {
    const dispatch = useDispatch();

    const schema = yup.object({
        firstName: yup.string()
                        .matches(/^[A-z]+$/, "Only alphabets are allowed for this field ")
                        .required("First Name is required!"),
        lastName: yup.string()
                        .matches(/^[A-z]+$/, "Only alphabets are allowed for this field ")
                        .required("Last name is required!"),
        email:    yup.string()
                        .email("Please input a proper email address!")
                        .required("Email is required!"),
        address:  yup.string()
                        .matches(/^[#.0-9a-zA-Z\s,-]+$/, 'Please use proper address format')
                        .required("Address is required!"),
        password: yup.string()
                        .matches(/^.*(?=.{6,})((?=.*[!@#$%^&*()\-_=+{};:,<.>]){1})(?=.*\d)((?=.*[a-z]){1})((?=.*[A-Z]){1}).*$/,
                        "Password must contain at least 6 characters, one uppercase, one number and one special case character")
                        .required("Password is required!")
    })

    const { handleSubmit, register, formState: { errors } } = useForm<IProfileCreationRequest>({
        resolver: yupResolver(schema),
        
    });

    const onSubmit = async (data: IProfileCreationRequest) => {
        console.table(data);
        await dispatch(postNewUser(data))
    };

    return(
        <div className="mt-5 container row">
            <div className="col-md-3"/>
            <form className="col-md-6" onSubmit={handleSubmit(onSubmit)}>
                <div className="form-row d-flex justify-content-between">
                    <div className="form-group col-md-6 ">
                        <label htmlFor="email">Email</label>
                        <input type="email" className="form-control" id="email" placeholder="Email" {...register("email")}/>
                        <p>{errors.email?.message}</p>
                    </div>
                    <div className="form-group col-md-6">
                        <label htmlFor="password">Password</label>
                        <input type="password" className="form-control" id="password" placeholder="Password"{...register("password")}/>
                        <p>{errors.password?.message}</p>
                    </div>
                </div>
                <div className="form-group">
                    <label htmlFor="address">Address</label>
                    <input type="text" className="form-control" id="address" placeholder="1234 Main St" {...register("address")}/>
                    <p>{errors.address?.message}</p>
                </div>
                <div className="form-group">
                    <label htmlFor="username">Username</label>
                    <input type="text" className="form-control" id="username" placeholder="Username" {...register("username")}/>
                    <p>{errors.username?.message}</p>
                </div>
                <div className="form-group">
                    <label htmlFor="firstName">First Name</label>
                    <input type="text" className="form-control" id="firstName" placeholder="First Name" {...register("firstName")}/>
                    <p>{errors.firstName?.message}</p>
                </div>
                <div className="form-group">
                    <label htmlFor="lastName">Last Name</label>
                    <input type="text" className="form-control" id="lastName" placeholder="Last Name" {...register("lastName")}/>
                    <p>{errors.lastName?.message}</p>
                </div>
                <button type="submit" className="btn btn-primary">Sign up</button>
            </form>
            <div className="col-md-3"/>
        </div>
    )
}