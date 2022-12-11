import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from "yup";
import { useDispatch } from "react-redux";
import { postLogin } from "../../redux/actions/login-actions";
import { useNavigate } from "react-router-dom";

export default function SignIn() {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const schema = yup.object({
        username: yup.string().required("Username is required!"),
        password: yup.string().required("Password is required!")
    });

    const { register, handleSubmit, formState: { errors, isDirty, isValid }} = useForm({
        resolver: yupResolver(schema),
        mode: "onChange"
    });

    const onSubmit = data => {
        data.jwTIssuer = "JWTAuthenticationServer";
        data.jwTAudience = "JWTServicePostmanClient";
        data.jwTSubject = "JWTServiceAccessToken";
        dispatch(postLogin(data))
    }

    return (
        <div className="col-md-12 mt-5">
            <div className="row mt-5">
                    <div className="col-md-4"/>
                    <div className="col-md-4 border border-5 border-danger text-center p-3 mx-auto">
                        <h2 className="text-danger">
                            Horrorbank
                        </h2>
                    </div>
                    <div className="col-md-4"/>
                </div>
            <form className="row g-3 mt-5 bg-dark bg-opacity-25" onSubmit={handleSubmit(onSubmit)}>
                <div className="form-group">
                    <label htmlFor="inputUsername" className="text-danger">Username</label>
                    <input type="username" className="form-control" id="inputUsername" placeholder="Enter email"{...register("username", {required:true})} aria-invalid={errors.username ? "true" : "false"} required/>
                    {errors.username?.type === 'required' && <p role="alert" className="text-danger">Username is required</p>}
                </div>
                <div className="form-group">
                    <label htmlFor="inputPassword" className="text-danger">Password</label>
                    <input type="password" className="form-control" id="inputPassword" placeholder="Password" {...register("password", {required:true})} aria-invalid={errors.password ? "true" : "false"} required/>
                    {errors.password?.type === 'required' && <p role="alert" className="text-danger">Password is required</p>}
                </div>
                <button type="submit" className="btn btn-danger" disabled={!isDirty || !isValid}>Submit</button>
            </form>
        </div>
    )
}