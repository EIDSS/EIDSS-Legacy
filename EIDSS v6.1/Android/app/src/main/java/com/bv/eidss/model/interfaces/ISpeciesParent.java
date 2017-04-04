package com.bv.eidss.model.interfaces;

import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.Species;

import java.util.List;


public interface ISpeciesParent {
    List<Species> getSpecies();
    void deleteSpecies(int pos);
    boolean canDeleteSpecies(int pos, Object parent);
    void setChanged();
    List<Long> getSpeciesTypes(long self);
    Boolean IsLivestockCase();
    Boolean IsASSession();
    long getId();
}
