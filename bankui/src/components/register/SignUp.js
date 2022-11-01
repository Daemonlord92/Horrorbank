import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from "yup";

export default function SignUp() {
    const schema = yup.object({
        firstName:      yup.string().required("First Name is a required field!"),
        lastName:       yup.string().required("Last Name is a required field!"),
        email:          yup.string().required("Email is a required field!"),
        address:        yup.string().required("Address is a required field!"),
        username:       yup.string().required("Username is a required field!"),
        password:       yup.string().required("Password is a required field!")
    })

    const { register, handleSubmit, formState: { errors }} = useForm({
        resolver: yupResolver(schema)
    })

    const onSubmit = (data) => console.log(data);

    return(
        <div className="col-md-12 mt-5">
            <div className="row">
                <div className="col-md-4"/>
                <div className="col-md-4 border border-5 border-danger text-center p-3 mx-auto">
                    <h2 className="text-danger">
                        Horrorbank
                    </h2>
                </div>
                <div className="col-md-4"/>
            </div>
            <form className="row g-3 mt-5 bg-dark bg-opacity-25" onSubmit={handleSubmit(onSubmit)}>
                <div className="col-md-6">
                    <label htmlFor="inputEmail4" className="form-label text-danger">Email</label>
                    <input type="email" className="form-control" id="inputEmail4" placeholder="slasher@horrorbank.com" {...register("email", { required: true })} aria-invalid={errors.email ? "true" : "false"}/>
                    {errors.email?.type === 'required' && <p role="alert" className="text-danger">Email is required</p>}
                </div>
                <div className="col-md-6">
                    <label htmlFor="inputPassword4" className="form-label text-danger">Password</label>
                    <input type="password" className="form-control" id="inputPassword4" placeholder="Password" {...register("password", {required:true})} aria-invalid={errors.password ? "true" : "false"}/>
                    {errors.password?.type === 'required' && <p role="alert" className="text-danger">Password is required</p>}
                </div>
                <div className="col-12">
                    <label htmlFor="inputAddress" className="form-label text-danger">Address</label>
                    <input type="text" className="form-control" id="inputAddress" placeholder="1234 Main St" {...register("address", {required:true})} aria-invalid={errors.address ? "true" : "false"}/>
                    {errors.address?.type === 'required' && <p role="alert" className="text-danger">Address is required</p>}
                </div>
                <div className="col-12">
                    <label htmlFor="inputUsername" className="form-label text-danger">
                        Username
                    </label>
                    <input type="text" className="form-control" id="inputUsername" placeholder="Myers78" {...register("username", {required:true})} aria-invalid={errors.username ? "true" : "false"}/>
                    {errors.username?.type === 'required' && <p role="alert" className="text-danger">Username is required</p>}
                </div>
                <div className="col-6">
                    <label htmlFor="inputFirstName" className="form-label text-danger">
                        First Name
                    </label>
                    <input type="text" className="form-control" id="inputFirstName" placeholder="Micheal" {...register("firstName", {required:true})} aria-invalid={errors.firstName ? "true" : "false"}/>
                    {errors.firstName?.type === 'required' && <p role="alert" className="text-danger">First name is required</p>}
                </div>
                <div className="col-6">
                    <label htmlFor="inputLastName" className="form-label text-danger">
                        Last Name
                    </label>
                    <input type="text" htmlFor="inputLastName" className="form-control" id="inputLastName" placeholder="Myers" {...register("lastName", {required:true})} aria-invalid={errors.lastName ? "true" : "false"}/>
                    {errors.lastName?.type === 'required' && <p role="alert" className="text-danger">Last name is required</p>}
                </div>
                <div className="col-12">
                    <button type="submit" className="btn btn-danger px-5">Sign in</button>
                </div>
                </form>
        </div>
    )
}