package com.example.EfarmingRESTServices.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.EfarmingRESTServices.entities.City;


@Repository
public interface CityRepository extends JpaRepository<City, Integer>{

}
