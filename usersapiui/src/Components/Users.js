import React,{useState, useEffect} from 'react';
import {variablesFromApi} from '../Variables/Variables';
import Modal from './Modal';


const UsersPage = () => {

    const [users, setUsers]= useState([]);
    const [userDetail, setUserDetail] = useState( {
        userId: 0,
        name: "",
        surname: "",
        emailAddress: "",
        userCity: "",
        street: "",
        isAdmin: "",
        dateOfBirth: ""
    });
    const [showModal, setShowModal] = useState(false);
    useEffect(() => {
        const url = variablesFromApi.API_URL + "User";
        const fetchData = async() => {
            try{
                const response = await fetch(url);
                const json = await response.json();
                setUsers( json.map(user =>({
                    userId: user.userId,
                    name: user.name,
                    surname: user.surname,
                    emailAddress: user.emailAddress
                })
                )
                );
                console.log(users);

            }
            catch(error){
                console.log("error",error);
            }
        }
        fetchData();
    }, []);

    const setModalIsOpen = (userId)=>{
        console.log("modal", userId);
        const url = variablesFromApi.API_URL + "User/"+userId;
        const fetchData = async() => {
            try{
                const response = await fetch(url);
                const json = await response.json();
                const newUserDetail =  {
                    userId: json.userId,
                    name: json.name,
                    surname: json.surname,
                    emailAddress: json.emailAddress,
                    userCity: json.userAddress.city,
                    street: json.userAddress.street,
                    isAdmin: json.userProfileSetting.isAdmin,
                    dateOfBirth: json.userProfileSetting.dateOfBirth
                };
                
                setUserDetail(newUserDetail);
                console.log(userDetail);
    
            }
            catch(error){
                console.log("error",error);
            }
        }
        fetchData();
        setShowModal(true);
    };

    const hideModal = () => {
        setShowModal(false);
    }

        return(
            <div>
                <h4> Users</h4>
                <div>
                <table>
                    <thead>
                        <tr>
                        <th>id</th>
                        <th>Name</th>
                        <th>Surname</th>
                        <th>Email</th>
                        </tr>
                    </thead>
                    <tbody>
                        {users.map(user =>
                                        
                        <tr>
                            <td>{user.userId}</td>
                            <td>{user.name}</td>
                            <td>{user.surname}</td>
                            <td>{user.emailAddress}</td>
                            <td><button onClick={() => setModalIsOpen(user.userId)}>UserDetail</button></td>
                        </tr>
                        )}

                    </tbody>
                </table>
            <Modal show={showModal} handleClose={hideModal}>
                <table >
                    <thead>
                        <tr>
                        <th>Name</th>
                        <th>Surname</th>
                        <th>Email</th>
                        <th>City</th>
                        <th>Street</th>
                        <th>Admin</th>
                        <th>Birthday</th>
                        
                        </tr>
                    </thead>
                    <tbody>
                    <tr>
                        <td>{userDetail.userId}</td>
                        <td>{userDetail.name}</td>
                        <td>{userDetail.surname}</td>
                        <td>{userDetail.emailAddress}</td>
                        <td>{userDetail.userCity}</td>
                        <td>{userDetail.street}</td>
                        <td>{userDetail.isAdmin}</td>
                        <td>{userDetail.dateOfBirth}</td>
                        </tr>
                    </tbody>
                </table>
            </Modal>
        </div>
    </div>
         
    )
}

export default UsersPage;
