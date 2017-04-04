package com.bv.eidss.model.interfaces;

import com.bv.eidss.FFPresenterFragment;
import com.bv.eidss.model.FFModel;

public interface IFFModel<R> {
    FFModel getFFModel(long idFormType);
    FFPresenterFragment getFFFragment(long idFormType);
    void SetDeterminant(long id);
    void OnLine();
    void OffLine();
}

