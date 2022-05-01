<?php

trait tbl_users
{
    public function db_connect()
    {
                $servername = "localhost";
                $username = "root";
                $password = "root";
                $dbname = "dbname";
              try {
        return new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
    } catch (PDOException $e) {
        echo $e->getMessage();
        return null;
    }
    }
    private function data_users_get($id){
        $conn = $this->db_connect();
        if ($conn != null) {
            $stmt = $conn->prepare("SELECT * FROM tbl_users WHERE id=:id");
            $stmt->bindValue('id', $id, PDO::PARAM_INT);
            $stmt->execute();
            return $stmt->fetch(PDO::FETCH_ASSOC);
        }
        return null;
    }

    private function data_users_get_ByEmail($email){
        $conn = $this->db_connect();
        if ($conn != null) {
            $stmt = $conn->prepare("SELECT * FROM tbl_users WHERE email=:email");
            $stmt->bindValue('email', $email, PDO::PARAM_STR);
            $stmt->execute();
            return $stmt->fetch(PDO::FETCH_ASSOC);
        }
        return null;
    }

    private function data_users_authentication($email,$password){
        $conn = $this->db_connect();
        if ($conn != null) {
            $stmt = $conn->prepare("SELECT * FROM tbl_users WHERE email= :email and password=:password");
            $stmt->bindValue('email', $email, PDO::PARAM_STR);
            $stmt->bindValue('password', $password, PDO::PARAM_STR);
            $stmt->execute();
            $count = $stmt->fetchColumn();
            if ($count > 0) {
                return true;
            } else
                return false;
        }
    }

    private function data_users_check_exists($email){
        $conn = $this->db_connect();
        if ($conn != null) {
            $stmt = $conn->prepare("SELECT * FROM tbl_users WHERE email=:email");
            $stmt->bindValue('email', $email, PDO::PARAM_STR);
            $stmt->execute();
            $count = $stmt->fetchColumn();
            if ($count > 0) // Already Exists Account
            {
                return true;
            }
            return false;//User not found
        }
    }

    private function data_users_add($data){
        $conn = $this->db_connect();
        if ($conn != null) {
            $stmt = $conn ->prepare("INSERT INTO tbl_users (email,password,name,last_name,phone_number,birth_date,account_status,image_path)
            VALUES (:email,:password,:name,:last_name,:phone_number,:birth_date,:account_status,:image_path)");
            foreach ($data as $key => $value) {
                $stmt->bindValue("$key", $value, PDO::PARAM_STR);
            }
            $stmt->execute();
        }
    }

    private function data_users_update($id,$data){
        $conn=$this->db_connect();
        if ($conn != null) {
            $stmt = $conn->prepare("UPDATE IGNORE tbl_users SET name=:name,last_name=:last_name,
            phone_number=:phone_number,birth_date=:birth_date,image_path=:image_path where id=:id");
            $stmt->bindValue("id", $id, PDO::PARAM_INT);
            foreach ($data as $key => $value) {
                $stmt->bindValue("$key", $value, PDO::PARAM_STR);
            }
            $stmt->execute();
        }
    }


    private function data_users_update_AccountStatus($id,$value){
        //Freeze account section
        $conn=$this->db_connect();
        if ($conn != null) {
            $stmt = $conn->prepare("UPDATE IGNORE tbl_users SET account_status=:account_status where id=:id");
            $stmt->bindValue('id', $id, PDO::PARAM_INT);
            $stmt->bindValue('account_status', $value, PDO::PARAM_INT);
            $stmt->execute();
        }
    }

    private function data_users_changePassword($id,$password){
        $conn=$this->db_connect();
        if ($conn != null) {
            $stmt = $conn->prepare("UPDATE IGNORE tbl_users SET password=:password where id=:id");
            $stmt->bindValue("id", $id, PDO::PARAM_INT);
            $stmt->bindValue("password", $password, PDO::PARAM_STR);
            $stmt->execute();
        }
    }

    private function data_users_changeEmail($id,$email){
        $conn=$this->db_connect();
        if ($conn != null) {
            $stmt = $conn->prepare("UPDATE IGNORE tbl_users SET email=:email where id=:id");
            $stmt->bindValue("id", $id, PDO::PARAM_INT);
            $stmt->bindValue("email",$email, PDO::PARAM_STR);
            $stmt->execute();
        }
    }

    private function data_users_remove($id){
        $conn = $this->db_connect();
        if ($conn != null) {
            $stmt = $conn->prepare("DELETE IGNORE FROM tbl_users WHERE id=:id");
            $stmt->bindValue('id', $id, PDO::PARAM_INT);
            $stmt->execute();
        }
    }
}