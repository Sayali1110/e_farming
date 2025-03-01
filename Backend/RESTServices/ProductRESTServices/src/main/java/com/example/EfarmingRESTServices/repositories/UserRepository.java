package com.example.EfarmingRESTServices.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.example.EfarmingRESTServices.entities.User;


@Repository
public interface UserRepository extends JpaRepository<User, Integer>{
	@Query("Select u from User u where u.uname = :uname and u.pwd = :pwd")
    Optional<User> getUser(@Param("uname") String uname, @Param("pwd") String pwd);

}
