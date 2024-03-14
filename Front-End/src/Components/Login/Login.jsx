import React, { useState, useEffect } from 'react';
import './Login.css';
import config from './config'; 
import { useHistory,useLocation } from 'react-router-dom';
import { MdEmail, MdVisibility, MdVisibilityOff } from "react-icons/md"; 
import { CiLock } from "react-icons/ci";
import { toast, Toaster } from 'react-hot-toast';

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [showPassword, setShowPassword] = useState(false); 
    const [id, setId] = useState();
    const navigate = useHistory();
    const [rememberMe, setRememberMe] = useState(false); 

    useEffect(() => {
        const storedUser = localStorage.getItem('rememberedUser');
        const storedPassword = localStorage.getItem('rememberedPassword');
        if (storedUser && storedPassword) {
            setEmail(storedUser);
            setPassword(storedPassword);
            setRememberMe(true); 
        }
    }, []);

    const handleRememberMeChange = () => {
        setRememberMe(!rememberMe);
    };

//comment
useEffect(() => {
        const registeredEmail = localStorage.getItem('registeredEmail');
        if (registeredEmail) {
            setEmail(registeredEmail);
            localStorage.removeItem('registeredEmail'); // Remove the email after fetching it
        }
     }, []); // Empty dependency array means this effect runs only once when component mounts

     useEffect(() => {
        const fetchUserName = async () => {
                const response = await fetch(`${config.ApiUrl}User/GetUserName${email}`);
                if (response.ok) {
                    const userData = await response.json();
                    setId(userData.id);
                } 
        };
        if(email)
        {
            fetchUserName();
        }
    }, [email]);

const handleUserChange = (e) => {
    setEmail(e.target.value);
};
    
    const handlePasswordChange = (e) => {
        setPassword(e.target.value);
    };

    const togglePasswordVisibility = () => { 
        setShowPassword(!showPassword);
    };
        
    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch(`${config.ApiUrl}User/Login`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ email, password })
            });
            if (response.ok) {

                const data = await response.json();
                setPassword(data.password);
                localStorage.setItem('loggedInEmail', email);
                if (rememberMe) {
                    localStorage.setItem('rememberedUser', email);
                    localStorage.setItem('rememberedPassword', password);
                } else {
                    localStorage.removeItem('rememberedUser');
                    localStorage.removeItem('rememberedPassword');
                }

                setTimeout(() => {
                    navigate.push('/UpdateUserDetail'); 
                }, 1500); 
                
                toast.success("Login Successfully!")
                localStorage.setItem("loggedEmail",JSON.stringify({
                    email,
                    id
                  }));
        
            } else if (response.status === 401) {
                const errorMessage = await response.text();
                toast.error(errorMessage);
            } else {
                toast.error('Login failed. Please try again later.');
            }
        } catch (error) {
            console.error('Login failed:', error);
            toast.error('Login failed');
        }
    };

    const customToastStyle = {
        fontFamily: "'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif",
        fontSize: '16px',
        fontWeight: 'bold',
      };

    return (
        <div className='containerl'>
            <form onSubmit={handleSubmit}>
                <h2>Login Form</h2>
                <input type='hidden' value={id}/>
                <div className='form-groupl'>
                    <label className='labell'>Email:</label>
                    <input
                        className='inputl'
                        type='email'
                        value={ email}
                        onChange={handleUserChange}
                        placeholder='Enter Your Email'
                        required
                    /> 
                </div>
                <CgMail className='icone'/>
                <div className='form-groupl'>
                    <label className='labell'>Password:</label>
                    <div className='password-input'>
                    <input className='inputl' type={showPassword ? 'text' : 'password'} value={password}     autoComplete="current-password"
                            onChange={handlePasswordChange} placeholder='Enter Your Password'
                         pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[~\@\!\#\$\%\^\&\*\?]).{8,15}$"
                         title="Must contain at least one  number and one uppercase and one lowercase letter and One special Charecter, and at least 8 characters"
                         required />
                        {showPassword ? <IoEyeOutline className='iconl' onClick={togglePasswordVisibility} /> : <IoEyeOffOutline  className='iconl' onClick={togglePasswordVisibility} />}
                    </div>
                </div>
                <div className='forgotl'>
                     <input type='checkbox' checked={rememberMe} onChange={handleRememberMeChange} /><span>Remember me</span>

                    <a href='ForgotPassword' className='f'>Forgot Password?</a>
                </div>
                <div>
                    <button type='submit' className='button'> Login </button>
                </div>
                <div className='register-link'>
                <p className='p'>Don't have an account? <a href='Registration' className='f'>Register</a></p>
            </div>
            </form>
            <Toaster toastOptions={{style: customToastStyle,duration:1500,}} position="top-center" reverseOrder={false} />
        </div>
    );
};

export default Login;