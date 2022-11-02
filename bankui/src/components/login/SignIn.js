import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from "yup";
import { useDispatch } from "react-redux";

export default function SignIn() {
    const dispatch = useDispatch();

    const schema = yup.object({
        username: yup.string().required("Username is required!"),
        password: yup.string().required("Password is required!")
    });

    const { register, handleSubmit, formState: { errors }} = useForm({
        resolver: yupResolver(schema)
    });

    const onSubmit = data => {
        console.table(data);
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
                    <input type="username" className="form-control" id="inputUsername" placeholder="Enter email"/>
                </div>
                <div className="form-group">
                    <label htmlFor="inputPassword" className="text-danger">Password</label>
                    <input type="password" className="form-control" id="inputPassword" placeholder="Password"/>
                </div>
                <button type="submit" className="btn btn-danger">Submit</button>
            </form>
        </div>
    )
}